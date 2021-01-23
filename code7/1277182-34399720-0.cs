    public class Porudzbina : List<PorudzbenicaStavka>, IEnumerable<SqlDataRecord>
    {
        [XmlElement]
        public long KomSifra { get; set; }
        [XmlElement]
        public Guid KomId { get; set; }
        IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        {
            var sqlRow = new SqlDataRecord(
                  new SqlMetaData("rb", SqlDbType.Int),
                  new SqlMetaData("RobaSifra", SqlDbType.NVarChar, 50),
                  new SqlMetaData("RobaNaziv", SqlDbType.NVarChar, 100)
                 );
            foreach (PorudzbenicaStavka por in this)
            {
                sqlRow.SetInt32(0, por.rb);
                sqlRow.SetString(1, por.RobaSifra);
                sqlRow.SetString(2, por.RobaNaziv);
                yield return sqlRow;
            }
        }
    }
    public class PorudzbenicaStavka
    {
        [XmlElement]
        public int rb { get; set; }
        [XmlElement]
        public string RobaSifra { get; set; }
        [XmlElement]
        public string RobaNaziv { get; set;  }
    }
