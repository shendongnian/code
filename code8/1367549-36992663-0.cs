    public object[,] ProcessSpreadsheet(string filename) {
        try {
            // Open MS Excel workbook
            // Open sheet & extract data into valueArray
            // ... more boiler plate ...
    
            return valueArray;
        }
        catch (FooException e) {
            LogFoo(e.Message);
            throw;
        }
        catch (BarException e) {
            LogBar(e.Message);
            throw;
        }
        finally {
            // Close workbook, release resources, etc..
        }
    }
