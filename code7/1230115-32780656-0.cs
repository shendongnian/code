            base.OnCreate(bundle);
            var codes = Intent.Extras.GetStringArrayList("Codes");
            codes.ToList();
            ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItemChecked, codes);
            ListView lv = FindViewById<ListView>(Android.Resource.Id.List);
            lv.ChoiceMode = ChoiceMode.Multiple;
            lv.Clickable = false;
            //CheckBox chk = lv.FindViewById<CheckBox>(Resource.Id.checkBox1);         
            foreach (var c in codes)
            {
                if (c.Contains("SENT SUCCESSFULLY"))
                {
                    int postion = codes.IndexOf(c);
                    lv.SetItemChecked(postion, true);
                    lv.Clickable = false;
                }
            }
        }
