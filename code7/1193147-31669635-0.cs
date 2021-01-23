    public string GetResultPIN()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(mIPAD.pin.KSN); 
               // Key Serial Number: 
               //a given number from the device, unique for each device
        sb.Append("," + mIPAD.pin.EPB);
               // EPB: encryption of PIN after Dubpt TripleDES,
               // essentially, EPB is PIN
        sb.Append("," + mIPAD.getStatusCode());
               //status code: Zero is good/done
               //             None-Zero is Error
        sb.Append("\r\n");
        Thread.Sleep(20*1000);  // it is in milliseconds
        return sb.ToString();
    }
