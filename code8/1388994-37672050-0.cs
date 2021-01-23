            List<string> list = new List<string>() {"2", "4"};
            CompositeFilterDescriptor compositeFilter = new CompositeFilterDescriptor();
            compositeFilter.LogicalOperator = FilterLogicalOperator.Or;
            foreach (var item in list)
            {
                compositeFilter.FilterDescriptors.Add(new FilterDescriptor("ID", FilterOperator.IsEqualTo, item));
            }
            this.radGridView1.Columns["IDCol"].FilterDescriptor = compositeFilter;
