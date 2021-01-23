	var query =
		from strOldLicense in OldlicenseList
		from subscriptionList in objSubscription.lstClsLicense
		select new { strOldLicense, subscriptionList };
	foreach (var x in query)
	{
		newLicenseList.Add(x.subscriptionList.license_key);
		isInserted = _objcertificate.UpdateClpInternalLicense(subscriptionKey, _objUserInfo.GetUserAcctId(), x.strOldLicense, x.subscriptionList.license_key, expiryDT);
		if (!isInserted)
		{
			new Log().logInfo(method, "Unable to update the Subscription key." + certID);
			lblErrWithRenewSubKey.Text = "Application could not process your request. The error has been logged.";
			lblErrWithRenewSubKey.Visible = true;
			return;
		}
		insertCount++;
		if (insertCount >= 4)
		{
			break;
		}
	}
