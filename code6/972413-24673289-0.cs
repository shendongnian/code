    public void ProcessMethod()
         {
              try
              {
                  var b = new B();
                  b.Process();
              }
              catch(DatabaseException ex)
              {
                  _logger.Debug(ex.Error);
              }
              catch(InvalidInputException ex)
              {
                  _logger.Debug(ex.Error);
              }
              catch(ProcessException ex)
              {
                  _logger.Debug(ex.Error);
              }
         }
