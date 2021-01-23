    <Grid>
         <Grid.Visibility>
              <MultiBinding Mode="OneWay" Converter={StaticResource OpenToVisibilityConverter}>
                  <Binding ElementName="CategoriesFilter" Path="[a Open property on your UserControl]" />
                  <Binding ElementName="TypesFilter" Path="[a Open property on your UserControl]" />
                  <Binding ElementName="BrandsFilter" Path="[a Open property on your UserControl]" />TypesFilter
              </MultiBinding>
         </Grid.Visibility>
    </Grid>
