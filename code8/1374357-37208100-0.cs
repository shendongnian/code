     protected override void OnDragEnter(DragEventArgs e)
            {
                base.OnDragEnter(e);
                WorkflowContainer workflowContainer = DesignerHelper.FindAncestor<WorkflowContainer>(e.OriginalSource as DependencyObject);
                if (workflowContainer != null)
                {
                    workflowContainer.IsDragMouseOver = true;
                }
            }
