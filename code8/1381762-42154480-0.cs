    using Android.App;
    using System.Threading.Tasks;
    public class Show_Dialog
    {
        public enum MessageResult
        {
            NONE = 0,
            OK = 1,
            CANCEL = 2,
            ABORT = 3,
            RETRY = 4,
            IGNORE = 5,
            YES = 6,
            NO = 7
        }
        Activity mcontext;
        public Show_Dialog(Activity activity) : base()
        {
            this.mcontext = activity;
        }
        /// <summary>
        /// Messbox function to show a massage box
        /// </summary>
        /// <param name="Title">to show Title for your messagebox</param>
        /// <param name="Message">to show Message for your messagebox</param>
        /// <param name="result">to get result for your messagebox; OK=1,   Cancel=2,   ingnore=3,   else=0</param>
        /// <param name="SetInverseBackgroundForced">to Set Inverse Background Forced</param>
        /// <param name="SetCancelable">to set force message box is cancelabel or no</param>
        /// <param name="PositiveButton">to show Title for PositiveButton</param>
        /// <param name="NegativeButton">to show Title for NegativeButton</param>
        /// <param name="NeutralButton">to show Title for your NeutralButton</param>
        /// <param name="IconAttribute">to show icon for your messagebox</param>
        /// <returns></returns>
        public Task<MessageResult> ShowDialog(string Title, string Message, bool SetCancelable = false, bool SetInverseBackgroundForced = false, MessageResult PositiveButton = MessageResult.OK, MessageResult NegativeButton = MessageResult.NONE, MessageResult NeutralButton = MessageResult.NONE, int IconAttribute = Android.Resource.Attribute.AlertDialogIcon)
        {
            var tcs = new TaskCompletionSource<MessageResult>();
            var builder = new AlertDialog.Builder(mcontext);
            builder.SetIconAttribute(IconAttribute);
            builder.SetTitle(Title);
            builder.SetMessage(Message);
            builder.SetInverseBackgroundForced(SetInverseBackgroundForced);
            builder.SetCancelable(SetCancelable);
            builder.SetPositiveButton((PositiveButton != MessageResult.NONE) ? PositiveButton.ToString() : string.Empty, (senderAlert, args) =>
                {
                    tcs.SetResult(PositiveButton);
                });
            builder.SetNegativeButton((NegativeButton != MessageResult.NONE) ? NegativeButton.ToString() : string.Empty, delegate
            {
                tcs.SetResult(NegativeButton);
            });
            builder.SetNeutralButton((NeutralButton != MessageResult.NONE) ? NeutralButton.ToString() : string.Empty, delegate
            {
                tcs.SetResult(NeutralButton);
            });
            Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
            {
            });
            Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
            {
                builder.Show();
            });
            // builder.Show();
            return tcs.Task;
        }
    }
