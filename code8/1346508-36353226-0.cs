        public Personel(int DriverId, string DriverName, string DriverSurname, string DriverPosition,
            bool DriverGender, string DriverImage, string DriverEmail, string Password,
            DateTime? DriverBirthDate)
        {
            this.DriverId = DriverId;
            this.DriverName = DriverName;
            this.DriverSurname = DriverSurname;
            this.DriverPosition = DriverPosition;
            this.Gender = DriverGender;
            this.DriverImage = DriverImage;
            this.DriverEmail = DriverEmail;
            this.Password = Password;
            this.BirthDate = DriverBirthDate;
        }
