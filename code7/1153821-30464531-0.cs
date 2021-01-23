    SpanQuery firstwordQuery = new SpanTermQuery(new Term("myField", "system"));
    //Unfortunately, Lucene.Net doesn't have SpanMultiTermQueryWrapper...
    SpanQuery secondwordQuery = new SpanRegexQuery(new Term("myField", "clean.*"));
    SpanQuery[] spanClauses = new SpanQuery[] {firstwordQuery, secondwordQuery};
    Query finalQuery = new SpanNearQuery(spanClauses, 0, true);
