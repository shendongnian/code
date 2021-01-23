    try
    {
        using (NationalInstruments.DAQmx.Task digitalWriteTask = new NationalInstruments.DAQmx.Task())
        {
            string[] channels = DaqSystem.Local.GetPhysicalChannels(PhysicalChannelTypes.DOPort, PhysicalChannelAccess.External);
                                        
            // Here is how I command the voltage of the system.
            digitalWriteTask.DOChannels.CreateChannel(channels[1], "port1", ChannelLineGrouping.OneChannelForAllLines);
            DigitalSingleChannelWriter writer = new DigitalSingleChannelWriter(digitalWriteTask.Stream);
            writer.WriteSingleSampleMultiLine(true, commandValue);
    
            // A clue I might be able to offer about DOChannel Tristate property?
            digitalWriteTask.DOChannels.All.Tristate = true;
        }
    }
    catch (Exception ex)
    {
        Console.Out.WriteLine(ex.Message);
        return false;
    }
