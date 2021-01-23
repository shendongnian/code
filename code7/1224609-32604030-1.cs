    public void DragContrinueHandler(object sender, QueryContinueDragEventArgs e)
            {
                if (e.Action == DragAction.Continue && e.KeyStates != DragDropKeyStates.LeftMouseButton)
                {
                    _dragdropWindow.Close();
                }
            }
