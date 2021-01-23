            var chk = (sender as CheckBox).DataContext as Shopping;
            if (chk == null)
            {
                return;
            }
            chk.IsCompleted = true;
            var lstItem = lstShop.Where(x => x.list.Equals(chk.list)).FirstOrDefault();
            //if (lstItem != null)
            //{
            //    lstshopNew.Remove(lstItem);
            //}            
            if (lstshopNew.Count > 0)
            {
                foreach (var item in lstshopNew.ToList())
                {
                    if (item.list.Equals(lstItem.list))
                    {
                        tItem = item.list;
                    }
                }
                if (!lstItem.list.Equals(tItem))
                {
                    lstshopNew.Add(chk);
                }
            }
            else
            {
                lstshopNew.Add(chk);
            }
        }
        private void checkboxSL_Unchecked(object sender, RoutedEventArgs e)
        {
            var chk = (sender as CheckBox).DataContext as Shopping;
            if (chk == null)
            {
                return;
            }
            chk.IsCompleted = false;
            var lstItem = lstShop.Where(x => x.list.Equals(chk.list)).FirstOrDefault();
            if (lstItem != null)
            {
                foreach (var item in lstshopNew.ToList())
                {
                    if (item.list.Equals(lstItem.list))
                    {
                        lstshopNew.Remove(item);
                    }
                }
            }
        }
