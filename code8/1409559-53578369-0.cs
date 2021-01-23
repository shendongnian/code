        /// <summary>
        ///     Normalized email
        /// </summary>
        public string NormalizedEmail {
            get
            {
                return Email.ToUpperInvariant();
            }
            set { }
        }
        /// <summary>
        ///     Concurrency stamp
        /// </summary>
        public virtual string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();
