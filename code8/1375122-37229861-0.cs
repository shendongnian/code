            private void ItemsSourceChanged(BindableObject bindableObject, IEnumerable oldvalue, IEnumerable newvalue)
        {
            var incc = oldvalue as INotifyCollectionChanged;
            if (incc != null)
            {
                incc.CollectionChanged -= Incc_CollectionChanged;
            }
            incc = newvalue as INotifyCollectionChanged;
            if (incc != null)
            {
                incc.CollectionChanged += Incc_CollectionChanged;
            }
            boxSelectorGrid.Children.Clear();
            foreach (object obj in newvalue)
            {
                boxSelectorGrid.Children.Add(new Label { Text = "LOL", TextColor = Color.FromHex("#000") });
            }
        }
        private void Incc_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    // handle Added rows
                    break;
                case NotifyCollectionChangedAction.Remove:
                    // handle deleting rows
                    break;
                case NotifyCollectionChangedAction.Move:
                    // handle moving rows
                    break;
                case NotifyCollectionChangedAction.Replace:
                    // handle replacing rows
                    break;
                case NotifyCollectionChangedAction.Reset:
                    // reload everything
                    break;
            }
        }
