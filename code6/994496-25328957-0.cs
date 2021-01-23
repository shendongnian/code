	[HttpPost]
	[ValidateAntiForgeryToken]
	public ActionResult Index(Contact c)
	{
		if (!ModelState.IsValid)
		{
			//should use client side validation for this as well.
                MessageBox.Show("You are missing data, please ensure all fields are correct.", "Important", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            return View();
		}
		SaveToXml(c);
		return SaveToDatabase(c);
				
	}
	
	public void SaveToXml(Contact c)
	{
		string ContactFileName = Path.GetFileName(String.Format("{0} {1}.xml", c.LastName, c.FirstName));
		ContactFileName = (@"C:\\Users\\kevin.schultz\\TestDocuments\\" + ContactFileName);
		if (System.IO.File.Exists(ContactFileName))
		{
			MessageBox.Show("The file already exists. A number will be added to create a unique file name", "Important", MessageBoxButtons.OK,
			MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
			int i = 0;
			while (System.IO.File.Exists(ContactFileName))
			{
				ContactFileName = String.Format("{0} - {1}", ContactFileName, i.ToString());
				i++;
			}
		}
		XmlSerializer ser = new XmlSerializer(c.GetType());
		StreamWriter myWriter = new StreamWriter(ContactFileName);
		ser.Serialize(myWriter, c);
		myWriter.Close();
	}
	
	public ActionResult SaveToDatabase(Contact s)
	{
		try
		{
			using (ContactDataEntities CustData = new ContactDataEntities())
			{
				CustData.dbContacts.Add(
					new dbContact()
					{
						FirstName = s.FirstName,
						LastName = s.LastName,
						PhoneHome = s.PhoneHome,
						PhoneCell = s.PhoneCell,
						Email = s.Email,
						Address = s.Address,
						City = s.City,
						State = s.State,
						ZipCode = s.ZipCode,
					});
				CustData.SaveChanges();
				return View("ContactSuccess");
			}
		}
		catch (Exception ex)
		{
			return View("ContactError");
		}
	}
