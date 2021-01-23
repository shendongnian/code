    private void RegisterObjectEvents(XElement xelement, XtraForm form)
        {             
            XElement fEventElement = xelement.Element("ObjectEvents");
            if (fEventElement != null)
            {
                var fSubElement = fEventElement.Elements();
                foreach (var item in fSubElement)
                {
                    if (!IsformEvent(item.Name.ToString()))
                    {
                        Control control = null;
                        for (int i = 0; i <= fObjectList.Count - 1; i++)
                        {
                            if (fObjectList[i].Name == GetObjectNameFromString(item.Name.ToString()))
                            {
                                control = fObjectList[i];
                                break;
                            }
                        }
                        if (control != null)
                        {
                            EventInfo ei = control.GetType().GetEvent(GetEventNameFromString(item.Name.ToString()));
                            Type tDelegate = ei.EventHandlerType;                           
                            EventHandler del = (o, args) => ExecuteLua(item.Value,o, args);
                            ei.AddEventHandler(control, ConvertDelegate(del, tDelegate));                                  
                        }
                    }
                }
            }
        }
