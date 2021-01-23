    private T SaveChangesWrapper<T>(Func<T> function)
    {
        try
        {
            //do some work up front....
    
            return function();
        }
        catch (DbEntityValidationException ex)
        {
            //parse exception and rethrow...
        }
        catch (DbUpdateConcurrencyException ex)
        {
            //parse and rethrow...
        }
        catch (DbUpdateException ex)
        {
            //parse and rethrow...
        }
        catch (Exception ex)
        {
            //parse and rethrow..
        }
    }
