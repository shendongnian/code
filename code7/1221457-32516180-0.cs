    FilterContainer filterContainer = null;
    
    filterContainer |= Filter<ElasticsearchMyDoc>.Term("concealed", true);
    filterContainer |= Filter<ElasticsearchMyDoc>.Term("govt", true);
    
    QueryContainer queryContainer = new MatchAllQuery();
    queryContainer &= Query<ElasticsearchMyDoc>.Term(l => l.StateType, 2);
    
    SearchDescriptor<ElasticsearchMyDoc> searchDescriptor = new SearchDescriptor<ElasticsearchMyDoc>();
    searchDescriptor.Query(qd => qd.Filtered(fq =>
        {
            fq.Filter(f => filterContainer);
            fq.Query(q => queryContainer);
        }));
    
    searchDescriptor.Size(5000);
    var searchResponse = Client.Search<ElasticsearchMyDoc>(s => searchDescriptor);
