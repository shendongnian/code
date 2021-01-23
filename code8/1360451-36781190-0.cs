    private void LoopAllElements(GuiComponentCollection nodes)
        {
            foreach (GuiComponent node in (GuiComponentCollection)nodes)
            {
                Console.WriteLine(node.Id);
                    if (node.ContainerType)
                    {
                        var children = ((node as dynamic).Children as GuiComponentCollection);
                        LoopAllElements(children);
                    }
            }
        }
