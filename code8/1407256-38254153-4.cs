            private void MRemindMe_Click(object sender, EventArgs e)
        {
            intRemind = new Intent(this, typeof(AlarmReceiver));
            //ToggleSwitch
            if (mvibrateSW.Checked)
            {
                intRemind.PutExtra("vChecked", "On");
            }
            //StartReminder 1-6hrs
            pendInt = PendingIntent.GetBroadcast(this, 0, intRemind, PendingIntentFlags.UpdateCurrent);
            alarmManager = (AlarmManager)GetSystemService(AlarmService);
            alarmManager.SetInexactRepeating(AlarmType.ElapsedRealtimeWakeup, SystemClock.ElapsedRealtime() + (1000 * mSeekBar.Progress), (1000 * mSeekBar.Progress), pendInt);
            mCancelNotif.Visibility = ViewStates.Visible;
        }
