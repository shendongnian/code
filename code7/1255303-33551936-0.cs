    public class KeyValuePair<K, V>
    {
        private K m_key;
        private V m_value;
        // [...] existing implementation left out
        public override bool Equals(object obj)
        {
            KeyValuePair<K, V> other = obj as KeyValuePair<K, V>;
            if(other == null)
                return false;
            return object.Equals(this.m_key, other.m_key) && object.Equals(this.m_value, other.m_value);
        }
    
        public override int GetHashCode()
        {
            int hashCode = 0;
            if(m_key != null)
                hashCode += m_key.GetHashCode();
            if(m_value != null)
                hashCode = hashCode * 31 + m_value.GetHashCode();
            return hashCode;
        }
    }
