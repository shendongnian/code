        private IEnumerable<PropertyInfo> GetProperties(object specimen)
        {
            return from pi in this.GetSpecimenType(specimen).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                   where pi.GetSetMethod() != null
                   && pi.GetIndexParameters().Length == 0
                   && this.specification.IsSatisfiedBy(pi)
                   select pi;
        }
