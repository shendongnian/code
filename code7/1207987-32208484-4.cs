    using System;
    using System.Data;
    using Dapper;
    namespace MyNamespace
    {
        internal class EnumParameter : SqlMapper.ICustomQueryParameter
        {
            #region Fields
            /// <summary>Enumerated parameter value</summary>
            private readonly Enum _val;
            #endregion
            #region Constructors
            /// <summary>Constructor</summary>
            /// <param name="val">Enumerated parameter value</param>
            public EnumParameter(Enum val)
            {
                _val = val;
            }
            #endregion
            #region Methods
            public void AddParameter(IDbCommand command, string name)
            {
                var param = command.CreateParameter();
                param.ParameterName = name;
                param.DbType = DbType.Object;
                param.Value = _val;
                command.Parameters.Add(param);
            }
            #endregion
        }
    }
