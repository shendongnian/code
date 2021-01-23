        // return employee data
        public override string ToString()
        {
            StringBuilder buffer = new StringBuilder();
            buffer.AppendLine($"Number: {EmployeeNumber}");
            buffer.AppendLine($"Name: {EmployeeName}");
            buffer.AppendLine($"Address: {PostalAddress}");
            buffer.AppendLine($"Phone: {PhoneNumber}");
            buffer.AppendLine($"Age: {EmployeeAge}");
            buffer.AppendLine($"Gender: {EmployeeGender}");
            buffer.AppendLine($"Status: {EmployeeStatus}");
            buffer.AppendLine($"Manager: {EmployeeManager}");
            buffer.AppendLine($"Start: {EmployeeStartDate.ToShortDateString()}");
            return buffer.ToString();
        }
