    struct Foo {
        public Byte   B;
        public Single F1;
        public Single F2;
        public Single F3;
        public void Serialize(EndianBinaryWriter wtr) {
            wtr.Write( B );
            wtr.Write( F1 );
            wtr.Write( F2 );
            wtr.Write( F3 );
        }
        public static Foo Deserialize(EndianBinaryReader rdr) {
            Foo f;
            f.B  = rdr.ReadByte();
            f.F1 = rdr.ReadSingle();
            f.F2 = rdr.ReadSingle();
            f.F3 = rdr.ReadSingle();
            return f;
        }
    }
