    public void ToDeleteConnectorByID(int connectorID) {
      try {
        EA.Connector addedConnector = Session.Repository.GetConnectorByID(Convert.ToInt32(connectorID));
        EA.Element currentobjectconnectorele = Session.Repository.GetElementByID(addedConnector.ClientID);
    
        for (short m = 0; m < currentobjectconnectorele.Connectors.Count; m++) {
          if (addConnector.ConnectorID == currentobjectconnectorele.ConnectorID) {
            currentobjectconnectorele.Connectors.Delete(m);
          }
        }
      }
      catch (Exception ex) {
        MessageBox.Show("no connector deleted-exception");
      }
    }
