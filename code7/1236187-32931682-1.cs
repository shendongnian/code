    public string CalcInternationalNumber()
    {
        var sw = Stopwatch.StartNew();
        try
        {
            if (Number == null || Region == null || DoesNumberContentValid() == false || NumberContentIsValid == false)
                return null;
            var phoneUtil = PhoneNumberUtil.GetInstance();
            var phone = phoneUtil.Parse(Number, Region);
            var intNum = phoneUtil.Format(phone, PhoneNumberFormat.INTERNATIONAL);
            Log.GetLogger().Info(Format.CreateLogMessage("converting mobile number completed successfully.", sw.Elapsed.TotalMilliseconds));
            return intNum;
        }
        catch (Exception ex)
        {
            Log.GetLogger().Error(Format.CreateLogMessage(ex.ToString(), sw.Elapsed.TotalMilliseconds));
            return null;
        }
    }
