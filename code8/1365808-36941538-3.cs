        /// <summary>
        /// Encodes 16-bit PCM input into A- or u-Law, presenting the output
        /// as an IWaveProvider.
        /// </summary>
        public class PcmToG711ConversionStream : IWaveProvider
        {
            /// <summary>Gets the local a-law or u-law format.</summary>
            public WaveFormat WaveFormat { get { return waveFormat; } }
            /// <summary>Returns <paramref name="count"/> encoded bytes.</summary>
            /// <remarks>
            /// Note that <paramref name="count"/> is raw bytes.  It doesn't consider
            /// channel counts, etc.
            /// </remarks>
            /// <param name="buffer">The output buffer.</param>
            /// <param name="offset">The starting position in the output buffer.</param>
            /// <param name="count">The number of bytes to read.</param>
            /// <returns>The total number of bytes encoded into <paramref name="buffer"/>.</returns>
            public int Read(byte[] buffer, int offset, int count)
            {
                // We'll need a source buffer, twice the size of 'count'.
                int shortcount = count*2;
                byte [] rawsource = new byte [shortcount];
                int sourcecount = Provider.Read(rawsource, 0, shortcount);
                int bytecount = sourcecount / 2;
                for( int index = 0; index < bytecount; ++index )
                {
                    short source = BitConverter.ToInt16(rawsource, index*2);
                    buffer[offset+index] = Encode(source);
                }
                return bytecount;
            }
            /// <summary>
            /// Initializes and A-Law or u-Law "WaveStream".  The source stream
            /// must be 16-bit PCM!
            /// </summary>
            /// <param name="_encoding">ALaw or MuLaw only.</param>
            /// <param name="_sourcestream">The input PCM stream.</param>
            public PcmToG711ConversionStream( WaveFormatEncoding _encoding,
                                              IWaveProvider _provider )
            {
                Provider = _provider;
                WaveFormat sourceformat = Provider.WaveFormat;
                if( (sourceformat.Encoding != WaveFormatEncoding.Pcm) &&
                    (sourceformat.BitsPerSample != 16) )
                {
                    throw new NotSupportedException("Input must be 16-bit PCM.  Try using a conversion stream.");
                }
                if( _encoding == WaveFormatEncoding.ALaw )
                {
                    Encode = this.EncodeALaw;
                    waveFormat = WaveFormat.CreateALawFormat( _provider.WaveFormat.SampleRate,
                                                              _provider.WaveFormat.Channels) ;
                                                                
                }
                else if( _encoding == WaveFormatEncoding.MuLaw )
                {
                    Encode = this.EncodeMuLaw;
                    waveFormat = WaveFormat.CreateMuLawFormat( _provider.WaveFormat.SampleRate,
                                                               _provider.WaveFormat.Channels) ;
                }
                else
                {
                    throw new NotSupportedException("Encoding must be A-Law or u-Law");
                }
            }
            /// <summary>The a-law or u-law encoder delegate.</summary>
            EncodeHandler Encode;
            /// <summary>a-law or u-law wave format.</summary>
            WaveFormat waveFormat;
            /// <summary>The input stream.</summary>
            IWaveProvider Provider;
            /// <summary>A-Law or u-Law encoder delegate.</summary>
            /// <param name="_sample">The 16-bit PCM sample to encode.</param>
            /// <returns>The encoded value.</returns>
            delegate byte EncodeHandler( short _sample );
            byte EncodeALaw( short _sample )
            {
                return ALawEncoder.LinearToALawSample(_sample);
            }
            byte EncodeMuLaw( short _sample )
            {
                return MuLawEncoder.LinearToMuLawSample(_sample);
            }
        }
        public class PcmToALawConversionStream : PcmToG711ConversionStream
        {
            public PcmToALawConversionStream( IWaveProvider _provider )
              : base(WaveFormatEncoding.ALaw, _provider)
            {
            }
        }
        public class PcmToMuLawConversionStream : PcmToG711ConversionStream
        {
            public PcmToMuLawConversionStream( IWaveProvider _provider )
              : base(WaveFormatEncoding.MuLaw, _provider)
            {
            }
        }
    }
