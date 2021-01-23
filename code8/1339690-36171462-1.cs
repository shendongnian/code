	/// <summary>The group</summary>
	enum eGroup : byte
	{
		A, B, C, D, E
	};
	static IEnumerable<eGroup> allGroups()
	{
		return Enum.GetValues( typeof( eGroup ) ).Cast<eGroup>();
	}
	/// <summary>Classify tag to the group, returns null if failed.</summary>
	static eGroup? classify( Tag tag )
	{
		string str = tag.Epc.ToString().ToUpper();
		foreach( eGroup e in allGroups() )
			if( str.Contains( e.ToString ) )
				return e;
		return null;
	}
	/// <summary>Add tag to list unless it's already there.</summary>
	static void addToList( List<Tag> list, Tag t )
	{
		int ind = list.IndexOf( t );
		if( ind < 0 )
			list.Add( t );	// Not on the list
		else if( list[ ind ].LastSeenTime.Utc < t.LastSeenTime.Utc )
			list[ ind ] = t; // Only replace if newer then the existing one
	}
	/// <summary>The collection to hold all that groups.</summary>
	readonly Dictionary<eGroup, List<Tag>> med = allGroups().ToDictionary( e => e, e => new List<Tag>() );
	/// <summary>True if that tag is too old.</summary>
	static bool isTooOld( Tag t )
	{
		ImpinjTimestamp ts = t.LastSeenTime;
		DateTime utc = new DateTime( 1970, 1, 1, 0, 0, 0, DateTimeKind.Utc ).AddTicks( (long)ts.Utc * 10L );
		return ( DateTime.UtcNow - utc ).TotalMilliseconds > 500;
	}
	void OnTagsReported( ImpinjReader sender, TagReport report )
	{
		// Classify and add to the correct group
		foreach( Tag tag in report )
		{
			eGroup? group = classify( tag );
			if( !group.HasValue ) continue;
			addToList( med[ group.Value ], tag );
		}
		// Remove too old tags
		foreach( var list in med.Values )
			list.RemoveAll( isTooOld );
		// Show counts
		int[] c = allGroups().Select( e => med[ e ].Count ).ToArray();
		SetText( c[ 0 ], c[ 1 ], c[ 2 ], c[ 3 ], c[ 4 ] );
	}
