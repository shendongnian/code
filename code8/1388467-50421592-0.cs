    using System;
    using PX.Data;
    namespace PX.Data
    {
        #region PXDBSecTimeSpanAttribute
        /// <summary>Maps a DAC field of <tt>int?</tt> type to the <tt>int</tt>
        /// database column. The field value represents a date as a number of
        /// seconds passed from 01/01/1900.</summary>
        /// <remarks>
        /// <para>The attribute is added to the value declaration of a DAC field.
        /// The field becomes bound to the database column with the same
        /// name.</para>
        /// <para>The field value stores a date as a number of seconds. In the UI,
        /// the string is typically represented by a control allowing a selection
        /// from the list of time values with half-hour interval.</para>
        /// </remarks>
        /// <example>
        /// <code>
        /// [PXDBSecTimeSpan]
        /// [PXUIField(DisplayName = "Run Time")]
        /// public virtual int? RunTime { get; set; ]
        /// </code>
        /// </example>
        public class PXDBSecTimeSpanAttribute : PXDBTimeSpanAttribute
        {
            #region State
            /// <summary>
            /// The "00:00:00" constant.
            /// </summary>
            public new const string Zero = "00:00:00";
            /// <summary>
            /// The BQL constant representing string "00:00:00".
            /// </summary>
            public new sealed class zero : Constant<string> { public zero() : base(Zero) { } }
            #endregion State
            #region Ctor
            /// <summary>
            /// Initializes a new instance with default parameters.
            /// </summary>
            public PXDBSecTimeSpanAttribute() : base()
            {
                _InputMask = "HH:mm:ss";
                _DisplayMask = "HH:mm:ss";
            }
            #endregion Ctor
            #region Implementation
            /// <exclude/>
            public override void FieldSelecting(PXCache sender, PXFieldSelectingEventArgs e)
            {
                if (_AttributeLevel == PXAttributeLevel.Item || e.IsAltered)
                {
                    e.ReturnState = PXDateState.CreateInstance(e.ReturnState, _FieldName, _IsKey, null, _InputMask, _DisplayMask, _MinValue, _MaxValue);
                }
                if (e.ReturnValue != null && (e.ReturnValue is int || e.ReturnValue is int?))
                {
                    TimeSpan span = new TimeSpan(0, 0, 0, (int)e.ReturnValue);
                    e.ReturnValue = new DateTime(1900, 1, 1).Add(span);
                }
            }
            /// <exclude/>
            public override void FieldUpdating(PXCache sender, PXFieldUpdatingEventArgs e)
            {
                if (e.NewValue == null || e.NewValue is int)
                {
                }
                else if (e.NewValue is string)
                {
                    DateTime val;
                    if (DateTime.TryParse((string)e.NewValue, sender.Graph.Culture, System.Globalization.DateTimeStyles.None, out val))
                    {
                        TimeSpan span = new TimeSpan(val.Hour, val.Minute, val.Second);
                        e.NewValue = (int)span.TotalSeconds;
                    }
                    else
                    {
                        e.NewValue = null;
                    }
                }
                else if (e.NewValue is DateTime)
                {
                    DateTime val = (DateTime)e.NewValue;
                    TimeSpan span = new TimeSpan(val.Hour, val.Minute, val.Second);
                    e.NewValue = (int)span.TotalSeconds;
                }
            }
            #endregion Implementation
            /// <summary>Returns the date obtained by adding the specified number of
            /// seconds to 01/01/1900.</summary>
            /// <param name="seconds">The seconds to add to the default date.</param>
            public static DateTime FromSeconds(int seconds)
            {
                TimeSpan span = new TimeSpan(0, 0, 0, seconds);
                return new DateTime(1900, 1, 1).Add(span);
            }
        }
        #endregion PXDBSecTimeSpanAttribute 
    }
