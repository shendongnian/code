    using (var reader = XmlReader.Create("descriptors.xml"))
    {
        while (reader.Read())
        {
            if (reader.ReadToFollowing("descriptor"))
            {
                int i = -1;
                do
                {
                    i++;
                    if (reader.ReadToFollowing("feature"))
                    {
                        int ii = 0;
                        do
                        {
                            ObjectDescriptors[i, ii] = reader.ReadElementContentAsFloat();
                            ii++;
                        } while (reader.ReadToNextSibling("feature"));
                    }
                } while (reader.ReadToNextSibling("descriptor"));
            }
        }
    }
