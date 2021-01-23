    //
    //  @(#) APNsDeviceToken.cs
    //
    //  Project:    usis Push Notification Router
    //  System:     Microsoft Visual Studio 2015
    //  Author:     Udo Schäfer
    using System.Diagnostics.CodeAnalysis;
    using Newtonsoft.Json;
    namespace usis.PushNotification
    {
        //  ----------------------
        //  APNsNotification class
        //  ----------------------
        /// <summary>
        /// Represents a notification that can be send to a device.
        /// </summary>
        public class APNsNotification
        {
            #region constants
            //  ---------------------
            //  DefaultSound constant
            //  ---------------------
            /// <summary>
            /// The name of the default sound file.
            /// </summary>
            public const string DefaultSound = "sound.caf";
            #endregion constants
            #region properties
            //  --------------
            //  Alert property
            //  --------------
            /// <summary>
            /// Gets or sets the alert message to display to the user.
            /// </summary>
            /// <value>
            /// The alert message to display to the user.
            /// </value>
            [JsonProperty(PropertyName = "alert", NullValueHandling = NullValueHandling.Ignore)]
            public string Alert { get; set; }
            //  --------------
            //  Badge property
            //  --------------
            /// <summary>
            /// Gets or sets the number to badge the app icon with.
            /// </summary>
            /// <value>
            /// The number to badge the app icon with.
            /// </value>
            [JsonProperty(PropertyName = "badge", NullValueHandling = NullValueHandling.Ignore)]
            public int? Badge { get; set; }
            //  --------------
            //  Sound property
            //  --------------
            /// <summary>
            /// Gets or sets the sound to play.
            /// </summary>
            /// <value>
            /// The sound to play.
            /// </value>
            [JsonProperty(PropertyName = "sound", NullValueHandling = NullValueHandling.Ignore)]
            public string Sound { get; set; }
            //  -------------------------
            //  ContentAvailable property
            //  -------------------------
            /// <summary>
            /// Gets or sets a value indicating whether new content is available.
            /// </summary>
            /// <value>
            ///   <c>true</c> if new content is available; otherwise, <c>false</c>.
            /// </value>
            [JsonProperty(PropertyName = "content-available", NullValueHandling = NullValueHandling.Ignore)]
            public bool ContentAvailable { get; set; }
            //  -----------------
            //  Category property
            //  -----------------
            /// <summary>
            /// Gets or sets a string value that represents the notification category.
            /// </summary>
            /// <value>
            /// A string value that represents the <c>identifier</c> property of the
            /// <c>UIMutableUserNotificationCategory</c> object you created to define custom actions.
            /// </value>
            [JsonProperty(PropertyName = "category", NullValueHandling = NullValueHandling.Ignore)]
            public string Category { get; set; }
            #endregion properties
            #region JsonWrapper class
            //  -----------------
            //  JsonWrapper class
            //  -----------------
            private class JsonWrapper
            {
                #region construction
                //  ------------
                //  construction
                //  ------------
                public JsonWrapper(APNsNotification aps) { Aps = aps; }
                #endregion construction
                #region properties
                //  ------------
                //  Aps property
                //  ------------
                [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
                [JsonProperty(PropertyName = "aps")]
                public APNsNotification Aps { get; private set; }
                #endregion properties
            }
            #endregion JsonWrapper class
            #region overrides
            //  ---------------
            //  ToString method
            //  ---------------
            /// <summary>
            /// Returns a <see cref="string" /> that represents this instance.
            /// </summary>
            /// <returns>
            /// A <see cref="string" /> that represents this instance.
            /// </returns>
            public override string ToString()
            {
                return JsonConvert.SerializeObject(new JsonWrapper(this));
            }
            #endregion overrides
        }
    }
    // eof "APNsDeviceToken.cs"
