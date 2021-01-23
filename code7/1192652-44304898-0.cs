    public override View GetView(int position, View convertView, ViewGroup parent)
    {
            var row = convertView;
            if (row == null)
            {
                row = LayoutInflater.From(mContext).Inflate(Resource.Layout.StudentScore_item, null, false);
            }
            var lblScoreId = row.FindViewById<TextView>(Resource.Id.lblScoreID);
            lblScoreId.Text = mItems[position].ID.ToString();
            var tbxScore_Final = row.FindViewById<EditText>(Resource.Id.tbxScore_Final);
            tbxScore_Final.Typeface = fontType;
            tbxScore_Final.Text =
                (mItems[position].FinalScore.HasValue ? mItems[position].FinalScore.ToString() : "");
            tbxScore_Final.Tag = mItems[position].ID;
            tbxScore_Final.FocusChange += (sender, e) =>
            {
                EditText tbx = sender as EditText;
                decimal score;
                bool isValidScore = decimal.TryParse(tbx.Text, out score);
                if (isValidScore)
                {
                    int inx = FindScoreIndex((int)tbx.Tag);
                    Log.WriteLine(
                        LogPriority.Info,
                        "Infooo",
                        string.Format(
                            "INDEX = {0} | ID = {1} | DATA = {2} | Validated = {3} | ==> {4}",
                            inx,
                            tbx.Tag.ToString(),
                            tbx.Text,
                            score.ToString(),
                            mItems[inx].ID
                        )
                    );
                    mItems[inx].FinalScore = score;
                }
            };
            return row;
        }
