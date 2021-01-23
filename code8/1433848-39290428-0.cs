        /// <summary>
        /// EA_OnPreNewConnector notifies Add-Ins that a new connector is about to be created on a diagram. 
        /// It enables Add-Ins to permit or deny creation of a new connector.
        /// </summary>
        /// <param name="Repository"></param>
        /// <param name="Info"></param>
        /// <returns>Return True to enable addition of the new connector to the model. Return False to disable addition of the new connector.</returns>
    public bool EA_OnPreNewConnector(EA.Repository Repository, EA.EventProperties Info)
    {
        try
        {
                //To get added Connector Type
                string connectorType = "";
                EA.EventProperty connectorTypePropID;
                connectorTypePropID = Info.Get(0);
                connectorType = connectorTypePropID.Value;
                //To get added Connector stereotype
                string connectorStereotype = "";
                EA.EventProperty connectorStereotypePropID;
                connectorStereotypePropID = Info.Get(2);
                connectorStereotype = connectorStereotypePropID.Value;
                //To get added Connector client ID
                int clientID = 0;
                EA.EventProperty clientIDPropID;
                clientIDPropID = Info.Get(3);
                clientID = Convert.ToInt32(clientIDPropID.Value);
                //To get added Connector Supplier ID
                int supplierID = 0;
                EA.EventProperty supplierIDPropID;
                supplierIDPropID = Info.Get(4);
                supplierID = Convert.ToInt32(supplierIDPropID.Value);
                //To get added Connector diagram
                int diagramID = 0;
                EA.EventProperty diagramIDPropID;
                diagramIDPropID = Info.Get(5);
                diagramID = Convert.ToInt32(diagramIDPropID.Value);
                EA.Element sourceElemnet = Session.Repository.GetElementByID(clientID);
                EA.Element destinationElemnet = Session.Repository.GetElementByID(supplierID);
                if (sourceElemnet != null && destinationElemnet != null)
                {
                   //Your condition based on when the connector needs to be created.
                    return true;
                }
               MessageBox.Show("This connection is not possible.");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("This connection is not possible.");
               return false;
            }
        }
