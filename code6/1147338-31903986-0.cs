        [FieldOrder(59),FieldAlign(AlignMode.Right, '0'),
         FieldConverter(typeof(SynergyHelper.DecimalConverter)),
         FieldFixedLength(5)]
        private Nullable<System.Int32 > m_CLOYAL;
        public Nullable<System.Decimal > CLOYAL
        {
            get
            {
                if (m_CLOYAL.HasValue)
                    return (System.Decimal)((System.Double)m_CLOYAL / Math.Pow(10, 2));
                return null;
            }
            set
            {
                m_CLOYAL = (System.Int32)(((System.Double)value.GetValueOrDefault()) * 
                                                          Math.Pow(10, 2));
            }
        }
