	private Regex _segmentTableLabel;
	Regex SegmentTableLabel
	{
		get
		{
			if (_segmentTableLabel == null)
				_segmentTableLabel = new Regex( @"^4.3.1\s{1,}Segment table$" );
			return _segmentTableLabel;
		}
	}
	private Regex _headerOrDetailOrSummarySection;
	Regex HeaderOrDetailOrSummarySection
	{
		get
		{
			if (_headerOrDetailOrSummarySection == null)
				_headerOrDetailOrSummarySection = new Regex( @"^\s+(?:HEADER SECTION|DETAIL SECTION|SUMMARY SECTION)$" );
			return _headerOrDetailOrSummarySection;
		}
	}
	private Regex _blankLines;
	Regex BlankLines
	{
		get
		{
			if (_blankLines == null)
				_blankLines = new Regex( @"^\s+\|*" );
			return _blankLines;
		}
	}
	private Regex _segmentTableHeader;
	Regex SegmentTableHeader
	{
		get
		{
			if (_segmentTableHeader == null)
				_segmentTableHeader = new Regex( @"^Pos\s{1,}Tag\s{1,}Name\s{1,}S\s{1,}R$" );
			return _segmentTableHeader;
		}
	}
	// reads: 00190       ---- Segment group 5  ------------------ C   200--------------+
	private Regex _segmentGroupHeader;
	Regex SegmentGroupHeader
	{
		get
		{
			if (_segmentGroupHeader == null)
				_segmentGroupHeader = new Regex( @"^(\d{1,5})\s{1,8}-{1,4}\sSegment group\s(\d{1,2})\s{1,}-{1,}\s(C|M)\s{1,3}(\d{1,})-{1,}(\++)\|*$" );
			return _segmentGroupHeader;
		}
	}
	// reads: 01420   DTM Date/time/period                         C   2------------+++++
	private Regex _segmentLineFull;
	Regex SegmentLineFull
	{
		get
		{
			if (_segmentLineFull == null)
				_segmentLineFull = new Regex( @"^(\d{1,5})\s{1,4}(\w+)\s(.{1,38})\s{1,3}(C|M)\s{1,3}(\d+)(?:-{0,}|\s*)(\+{0,})\|*$" );
			return _segmentLineFull;
		}
	}
	// reads: 00250   SPS Sampling parameters for summary                               |
	private Regex _segmentLineFragmentFirst;
	Regex SegmentLineFragmentFirst
	{
		get
		{
			if (_segmentLineFragmentFirst == null)
				_segmentLineFragmentFirst = new Regex( @"^(\d{1,5})\s{1,4}(\w+)\s(.{1,38})\s{1,24}\|$" );
			return _segmentLineFragmentFirst;
		}
	}
	// reads:                statistics                            C   1                |
	private Regex _segmentLineFragmentLast;
	Regex SegmentLineFragmentLast
	{
		get
		{
			if (_segmentLineFragmentLast == null)
				_segmentLineFragmentLast = new Regex( @"^\s{1,15}(.{1,38})(C|M)\s{1,4}(\d{1,})\s{1,}\|+$" );
			return _segmentLineFragmentLast;
		}
	}
    ...
    ...
	switch (getLineType( line ))
	{
		case Common.LineType.SegmentGroupHeader:
			// process segment group header
			break;
		case Common.LineType.SegmentLine:
			// process segment table line...
			break;
		case Common.LineType.SegmentLineBrokenFirst:
			// process a fragmented segment line...
			readNextLine = true;
			break;
		case Common.LineType.Ignore:
			// ignore line...
			break;
		default:
			if (!string.IsNullOrEmpty( line ))
				errors.Add( string.Format( "Unknown line type {0}", line ) );
			break;
	}
    ...
    ...
	Common.LineType getLineType( string line )
	{
		Common.LineType lineType = Common.LineType.Unknown;
		if (SegmentGroupHeader.IsMatch( line ))
			lineType = Common.LineType.SegmentGroupHeader;
		else if (SegmentLineFull.IsMatch( line ))
			lineType = Common.LineType.SegmentLine;
		else if (SegmentLineFragmentFirst.IsMatch( line ))
			lineType = Common.LineType.SegmentLineBrokenFirst;
		else if (SegmentLineFragmentLast.IsMatch( line ))
			lineType = Common.LineType.SegmentLineBrokenLast;
		else if (MessageStructureLabel.IsMatch( line ))
			lineType = Common.LineType.Ignore;
		else if (SegmentTableLabel.IsMatch( line ))
			lineType = Common.LineType.Ignore;
		else if (SegmentTableHeader.IsMatch( line ))
			lineType = Common.LineType.Ignore;
		else if (HeaderOrDetailOrSummarySection.IsMatch( line ))
			lineType = Common.LineType.Ignore;
		else if (BlankLines.IsMatch( line ))
			lineType = Common.LineType.Ignore;
		return lineType;
	}
