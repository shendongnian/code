        public List<Medicine> GetMedicine(DataRowCollection rows)
        {
            List<Medicine> medicines = new List<Medicine>();
            foreach (DataRow row in rows)
            {
                Medicine medicine = new Medicine();
                medicine.BrandName = row["BrandName"] == null ? string.Empty : row["BrandName"].ToString();
                medicine.GenericName = row["GenericName"] == null ? string.Empty : row["GenericName"].ToString();
                //more rows here to populate Medicine object
                //include the call to whatever methods are needed to populate the object
                medicines.Add(medicine);
            }
            return medicines;
        }
