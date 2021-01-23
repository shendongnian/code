        public void FormatDateTimePickers(Form customform)
        {
            foreach (Control c in customform.Controls)
            {
                var dateTimePicker = c as DateTimePicker;
                if (dateTimePicker != null)
                {
                    dateTimePicker.Format = DateTimePickerFormat.Custom;
                    dateTimePicker.CustomFormat = "dd/MM/yyyy";
                }
            }
        }
