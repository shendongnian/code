    var ordered = allrows.OrderBy(x => 0);
    if (!string.IsNullOrEmpty(SelectedScore))
        ordered = ordered.ThenByDescending(o => int.Parse(o[SelectedScore].ToString()));
    if (!string.IsNullOrEmpty(FirstSelected))
        ordered = ordered.ThenByDescending(o => int.Parse(o[FirstSelected].ToString()));
    if (!string.IsNullOrEmpty(SecondSelected))
        ordered = ordered.ThenByDescending(o => int.Parse(o[SecondSelected].ToString()));
