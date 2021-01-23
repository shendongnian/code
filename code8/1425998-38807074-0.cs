     if (e.Data.GetDataPresent(typeof(ComponentSelectionControl)))
                {
                    var csc = e.Data.GetData("IDA.Controls.ComponentSelectionControl");
                    e.Effect = DragDropEffects.Copy;
                    Log("Component Model Data is Present");
                  
                  
                }
                else
                    Log("Component Model Data is NOT Present");
