    public static void Main()
    {
        try
        {
            var instrument = new Instrument();
            try
            {
                instrument.TurnOnInstrument();
                instrument.DoSomethingThatMightThrowAnException();
                throw new Exception();
            }
            finally
            {
                if(instrument != null)
                    instrument.TurnOffInstrument();
            }
        }
        catch(Exception)
        {
             Console.Writeline("An exception occured");
        }
    }
