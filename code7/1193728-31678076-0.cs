            var items = Common.Deserialize<DiagnosisItem[]>(path, false);
            if (items == null)
                return;
            foreach (var item in items)
            {
                var find = _items.Where(o => o.Value.Tooltip == item.Id).FirstOrDefault();
                if (find.Value == null)
                    continue;
                find.Value.Text = item.Text;
                find.Value.Color = (Color)converter.ConvertFromInvariantString(item.Color);
            }
