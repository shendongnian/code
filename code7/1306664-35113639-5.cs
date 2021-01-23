                    //here is in my opinion the correct algorithm in this case
                    var elementFromInputs = _elementInputs[i] as UIElement;
                    if (elementFromInputs == null) continue;
                    //try to find parent of type Panel
                    var parentPanel = elementFromInputs.FindParent<Panel>();
                    //try to find parent of type ContentControl
                    var parentContentControl = elementFromInputs.FindParent<ContentControl>();
                    if (parentPanel == null && parentContentControl == null)
                    {
                        //add if there is no any parents
                        grid.Children.Add(elementFromInputs);
                    }
                    if (parentPanel != null)
                    {
                        //remove element from parent's collection
                        parentPanel.Children.Remove(elementFromInputs);
                    }
                    if(parentContentControl != null)
                    {
                        //reset parent content to release element
                        parentContentControl.Content = null;
                    }
                    grid.Children.Add(elementFromInputs);
