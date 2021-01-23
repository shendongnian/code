           public void WriteFloat(float v, ref byte[] m_Buffer, int m_Offset)
            {
                BitConverter.GetBytes(v).CopyTo(m_Buffer, m_Offset);
            }
            public float ReadFloat(byte[] m_Buffer, int m_Offset)
            {
                return BitConverter.ToSingle(m_Buffer, m_Offset);
            }​
