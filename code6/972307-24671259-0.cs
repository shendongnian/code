            Type collectionType = dg.ItemsSource.GetType();
            if (collectionType.IsGenericType && collectionType.GetGenericTypeDefinition().IsAssignableFrom(typeof(ObservableCollection<>)))
            {
                Type objType = collectionType.GenericTypeArguments[0];
            }
