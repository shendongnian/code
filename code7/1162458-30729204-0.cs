    piravte void ReadElement(XmlTextReader reader,string enterElement,string exitElement, Delegate LoadElement, object yourReader, objectyourType))
    {
    	while (reader.Read())
            {
                if (StateElement(State.Enter, enterElement, reader))
                {
                    LoadElement.DynamicInvoke(yourReader, yourType);
                }
                else if (StateElement(State.Exit, exitElement, reader))
                {
                    break;
                }
            }
    }
