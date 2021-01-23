    //Adding a client callback 
    OperationContext context = OperationContext.Current;
    ICallback callback = context.GetCallbackChannel(); 
    ICommunicationObject obj = (ICommunicationObject)callback; 
    obj.Closed += new EventHandler(obj_Closed);
    //Event for inactive clients
     void obj_Closed(object sender, EventArgs e)
        {
            if (_callbacks.ContainsValue(((ITecnobelRemoteServiceCallback)sender)))
            {
                var item = _callbacks.First(kvp => kvp.Value == ((ITecnobelRemoteServiceCallback)sender));
                _callbacks.Remove(item.Key);
                treeViewClients.Nodes.RemoveByKey(item.Key.Id);
                treeViewClients.Refresh();
                _registeredUsers--;
                listBoxStatus.Items.Add(String.Format("Usuário {0} estava inativo e foi removido", item.Key.Id));
            }
        }
