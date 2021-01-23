            private void StartTimeInput_Click(object sender, EventArgs e)
        {
            TimePickerFragment frag = TimePickerFragment.NewInstance(delegate (TimeSpan time)
            {
                startTimeInput.Text = time.ToString();
            });
            frag.Show(FragmentManager, TimePickerFragment.TAG);
        }
