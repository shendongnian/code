       private void propertyGridControl1_CellValueChanged(object sender, CellValueChangedEventArgs e)
       {
            var changedObject = e.Value;
            if (changedObject != null)
            {
                if (changedObject.GetType().IsArray || changedObject.GetType().IsGenericList())
                {
                    var collectionItems = changedObject as IEnumerable;
                    if (collectionItems != null)
                        foreach (var item in collectionItems)
                        {
                            SetValueOfCollectionComplexObject(item);
                        }
                }
            }
        }
    public void SetValueOfCollectionComplexObject(object item)
    {
            var complexProps = item.GetType().GetProperties().Where(x => !x.PropertyType.IsSimpleType());
            foreach (var prop in complexProps)
            {
                if (prop.GetValue(item) == null)
                {
                    prop.SetValue(item, Activator.CreateInstance(prop.PropertyType));
                    SetValueOfCollectionComplexObject(prop.GetValue(item));
                }
            }
        }
