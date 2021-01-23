           using (var client = new TestServiceClient())
			{
                // Get the channel factory
                var factory = client.ChannelFactory;
                // Attach the behavior
                foreach (OperationDescription desc in factory.Endpoint.Contract.Operations)
                {
                    DataContractSerializerOperationBehavior dcsOperationBehavior = desc.Behaviors.Find<DataContractSerializerOperationBehavior>();
                    if (dcsOperationBehavior != null)
                    {
                        int idx = desc.Behaviors.IndexOf(dcsOperationBehavior);
                        desc.Behaviors.Remove(dcsOperationBehavior);
                        desc.Behaviors.Insert(idx, new WcfClient.NetDataContractAttribute.NetDataContractSerializerOperationBehavior(desc));
                        //return true;
                    }
                }
				// pass
				client.PassInt(0);
				// fail
				client.PassGuid(Guid.NewGuid());
				client.Close();
			}
