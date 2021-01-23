    using (var unitOfWork = new UnitOfWork())
    {
        try
        {
            Prepare();
            Step1();
            Step2();
            unitOfWork.Commit();
        }
        catch(PrepareException e)
        {
            //no necessary to rollback, just log it
        }
        catch(FirstStepException e1)
        {
            //rollback step1
        }
        catch(SecondStepException e2)
        {
            //rollback step1 and step2
        }
    }
