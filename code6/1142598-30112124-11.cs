    @model TreeVM
    <ul>
      @while(Model.Nodes.Count > 0)
      {
        var currentNode = Model.Nodes.Pop();
        @* we reached a node with an EndTag Value
           must render closing tag 
        *@
        if (!currentNode.EndTag.IsNullOrEmpty())
        {
          @: @currentNode.EndTag 
        }
        @* we reached a node we haven't seen before
        *@
        else
        {
          // Create our node <LI>
          var li = new TagBuilder("li");
          li.AddCssClass("my css classes");
          li.MergeAttributes("id", currentNode.Id.ToString();
          var endTag = li.ToString(TagRenderMode.EndTag);
          // Render out our LI start tag
          @: @(new MvcHtmlString(li.ToString(TagRenderMode.StartTag)))
          // Do we have subnodes?
          var hasSubNodes = currentNode.Nodes.Count > 0;
          if (hasSubNodes)
          {
            // Need a new UL
            var ul = new TagBuilder("ul");
            li.AddCssClass("my css classes");
            li.MergeAttributes("id", currentNode.Id.ToString();
            // Render out our UL start Tag
            @: @(new MvcHtmlString(ul.ToString(TagRenderMode.StartTag)))
            // End tag should be opposite order </ul></li>
            endTag = ul.ToString(TagRenderMode.EngTag) + endTag;
          }
          // Put the node back in the stack
          currentNode.EndTag = new MvcHtmlString(endTag);
          Model.Nodes.Push(currentNode);
          // Push all sub nodes in the stack
          if (hasSubNodes)
          {
            foreach(var subNode in currentNode.Nodes)
            {
              Model.Nodes.Push(subNode);
            }
          }
          <text>
          Whatever you want in the LI
          </text>
        }
      }
