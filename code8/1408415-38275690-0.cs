    private int DeleteContentFromSiblingTree(SplayTreeNode containingNode, TextPointer startPosition, TextPointer endPosition, bool newFirstIMEVisibleNode, out int charCount)
	{
		SplayTreeNode leftSubTree;
		SplayTreeNode middleSubTree;
		SplayTreeNode rightSubTree;
		SplayTreeNode rootNode;
		TextTreeNode previousNode;
		ElementEdge previousEdge;
		TextTreeNode nextNode;
		ElementEdge nextEdge;
		int symbolCount;
		int symbolOffset;
	
		// Early out in the no-op case. CutContent can't handle an empty content span.
		if (startPosition.CompareTo(endPosition) == 0)
		{
			if (newFirstIMEVisibleNode)
			{
				UpdateContainerSymbolCount(containingNode, /* symbolCount */ 0, /* charCount */ -1);
			}
			charCount = 0;
			return 0;
		}
	
		// Get the symbol offset now before the CutContent call invalidates startPosition.
		symbolOffset = startPosition.GetSymbolOffset();
	
		// Do the cut.  middleSubTree is what we want to remove.
		symbolCount = CutContent(startPosition, endPosition, out charCount, out leftSubTree, out middleSubTree, out rightSubTree);
	
		// We need to remember the original previous/next node for the span
		// we're about to drop, so any orphaned positions can find their way
		// back.
		if (middleSubTree != null)
		{
			if (leftSubTree != null)
			{
				previousNode = (TextTreeNode)leftSubTree.GetMaxSibling();
				previousEdge = ElementEdge.AfterEnd;
			}
			else
			{
				previousNode = (TextTreeNode)containingNode;
				previousEdge = ElementEdge.AfterStart;
			}
			if (rightSubTree != null)
			{
				nextNode = (TextTreeNode)rightSubTree.GetMinSibling();
				nextEdge = ElementEdge.BeforeStart;
			}
			else
			{
				nextNode = (TextTreeNode)containingNode;
				nextEdge = ElementEdge.BeforeEnd;
			}
	
			// Increment previous/nextNode reference counts. This may involve
			// splitting a text node, so we use refs.
			AdjustRefCountsForContentDelete(ref previousNode, previousEdge, ref nextNode, nextEdge, (TextTreeNode)middleSubTree);
	
			// Make sure left/rightSubTree stay local roots, we might
			// have inserted new elements in the AdjustRefCountsForContentDelete call.
			if (leftSubTree != null)
			{
				leftSubTree.Splay();
			}
			if (rightSubTree != null)
			{
				rightSubTree.Splay();
			}
			// Similarly, middleSubtree might not be a local root any more,
			// so splay it too.
			middleSubTree.Splay();
	
			// Note TextContainer now has no references to middleSubTree, if there are
			// no orphaned positions this allocation won't be kept around.
			Invariant.Assert(middleSubTree.ParentNode == null, "Assigning fixup node to parented child!");
			middleSubTree.ParentNode = new TextTreeFixupNode(previousNode, previousEdge, nextNode, nextEdge);
		}
	
		// Put left/right sub trees back into the TextContainer.
		rootNode = TextTreeNode.Join(leftSubTree, rightSubTree);
		containingNode.ContainedNode = rootNode;
		if (rootNode != null)
		{
			rootNode.ParentNode = containingNode;
		}
	
		if (symbolCount > 0)
		{
			int nextNodeCharDelta = 0;
			if (newFirstIMEVisibleNode)
			{
				// The following node is the new first ime visible sibling.
				// It just moved, and loses an edge character.
				nextNodeCharDelta = -1;
			}
	
			UpdateContainerSymbolCount(containingNode, -symbolCount, -charCount + nextNodeCharDelta);
			TextTreeText.RemoveText(_rootNode.RootTextBlock, symbolOffset, symbolCount);
			NextGeneration(true /* deletedContent */);
	
			// Notify the TextElement of a content change. Note that any full TextElements
			// between startPosition and endPosition will be handled by CutTopLevelLogicalNodes,
			// which will move them from this tree to their own private trees without changing
			// their contents.
			Invariant.Assert(startPosition.Parent == endPosition.Parent);
			TextElement textElement = startPosition.Parent as TextElement;
			if (textElement != null)
			{               
				textElement.OnTextUpdated();                    
			}
		}
	
		return symbolCount;
	}
