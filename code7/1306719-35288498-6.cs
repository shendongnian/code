        public async Task PublishData()
        {
            communicationCallback = (ICommunicationObject)service.Callback;
            if (communicationCallback.State == CommunicationState.Opened)
            {
                    await service.Callback.OnPushData(data);
            }
        }
