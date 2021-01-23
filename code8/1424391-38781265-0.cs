        #region Constants
        private const double dblPIE = 3.14d;
        #endregion
        #region Member_Variables
        private double m_dblMajorRad = 0.0d;
        private double m_dblMinorRad = 0.0d;
        #endregion
    
        #region Constructors
        /// <summary>
        /// default constructor
        /// </summary>
        public Oval()
        {
        }
        /// <summary>
        /// initializes Major Radius and Minor Radius of oval
        /// </summary>
        /// <param name="dblOvalMajorRad"></param>
        /// <param name="dblOvalMinorRad"></param>
        public Oval(double dblOvalMajorRad, double dblOvalMinorRad)
        {
            m_dblMajorRad = dblOvalMajorRad;
            m_dblMinorRad = dblOvalMinorRad;
        }
        #endregion
    }
