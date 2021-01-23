                        foreach (SPListItem oListItem in collListItems)
                        {
                               //file.UndoCheckOut();
                                //file.CheckOut();
                                oListItem.File.UndoCheckOut();
                                oListItem.File.CheckOut();
                               SPListItem itemToDelete = list.GetItemById(oListItem.Id);
                               itemToDelete.Delete();
                        }
