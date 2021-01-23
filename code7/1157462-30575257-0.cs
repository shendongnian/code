    internal abstract class MessageProcessing {
      // TODO: declare event variable
      abstract string ProcessInternalMessage(HubMessage message);
      void ProcessMessage(HubMessage message) {
        // Here he call the ProcessInternalMessage which returns
        // the path. Depending on the derived class the logic or the processor.
        string path = this.ProcessInternalMessage(message);
        // here we raise event with the path in the parameters
      }
    }
