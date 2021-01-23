    public async Task ProcessSpreadsheetAsync(string filename, Func<object[,],Task> process) {
      try {
        // Open MS Excel workbook
        // Open sheet & extract data into valueArray
        // ... more boiler plate ...
        await process(valueArray);
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
