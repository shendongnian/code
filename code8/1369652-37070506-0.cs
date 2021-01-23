        /// <summary>
        /// Gets or sets the actual maximum value of the axis.
        /// </summary>
        /// <remarks>If "ViewMaximum" is not NaN, this value will be defined by "ViewMaximum".
        /// Otherwise, if "Maximum" is not NaN, this value will be defined by "Maximum".
        /// Otherwise, this value will be defined by the maximum (+padding) of the data.</remarks>
        public double ActualMaximum { get; protected set; }
        /// <summary>
        /// Gets or sets the maximum value of the axis. The default value is double.NaN.
        /// </summary>
        public double Maximum { get; set; }
        /// <summary>
        /// Gets or sets the 'padding' fraction of the maximum value. The default value is 0.01.
        /// </summary>
        /// <remarks> A value of 0.01 gives 1% more space on the maximum end of the axis. This property is not used if the "Maximum" property is set.</remarks>
        public double MaximumPadding { get; set; }
        /// <summary>
        /// Gets or sets the current view's maximum. This value is used when the user zooms or pans.
        /// </summary>
        /// <value>The view maximum.</value>
        protected double ViewMaximum { get; set; }
