        public Entities.ServiceResult<Customer> CustomerChangePassword(string CustomerId, string OldPassword, string NewPassword)
        {
            long _customerId = Convert.ToInt32(CustomerId);
            byte[] _oldPassword = Encoding.ASCII.GetBytes(OldPassword);
            var _result = from c in context.customers where (c.CustomerId == _customerId) select c;
    
            if (_result == null || _result.Count() == 0)
            {
                return new Entities.ServiceResult<Customer>
                {
                    ErrorState = 1,
                    Message = "User does not exists."
                };
            }
    
            var customer = _result.First();
            if (!customer.Password.SequenceEqual(_oldPassword))
            {
                return new Entities.ServiceResult<Customer>
                {
                    ErrorState = 1,
                    Message = "Old Password Is Wrong."
                };
            }
            customer.Password = Encoding.ASCII.GetBytes(NewPassword);
            context.SaveChanges();
            return new Entities.ServiceResult<Customer>
            {
                ErrorState = 0,
                Message = "Password Changed Successfully."
            };
        }
