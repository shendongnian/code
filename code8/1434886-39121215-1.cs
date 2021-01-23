		public void printAppReceipt()
		{
			NSUrl receiptURL = NSBundle.MainBundle.AppStoreReceiptUrl;
			if (receiptURL != null)
			{
				Console.WriteLine("receiptUrl='" + receiptURL + "'");
				NSData receipt = NSData.FromUrl(receiptURL);
				if (receipt != null)
				{
					byte[] rbytes = receipt.ToArray();
					AppleAppReceipt apprec = new AppleAppReceipt();
					if (apprec.parseAsn1Data(rbytes))
					{
						Console.WriteLine("Received receipt for " + apprec.BundleIdentifier + " with " + apprec.PurchaseReceipts.Count +
						                  " products");
						Console.WriteLine(JsonConvert.SerializeObject(apprec,Formatting.Indented));
					}
				}
				else
					Console.WriteLine("receipt == null");
			}
		}
